const app = Vue.createApp({
        components: {
            EasyDataTable: window['vue3-easy-data-table'],
        },
        data() {
            return {
                todoItemsRows: [
                    {id: 1, status: "Done", description: "Buy milk", createdAt: "2021-10-01", updatedAt: "2021-10-02"},
                    {id: 2, status: "Done", description: "Buy eggs", createdAt: "2021-10-01", updatedAt: "2021-10-02"},
                    {id: 3, status: "Done", description: "Buy bread", createdAt: "2021-10-01", updatedAt: "2021-10-02"},
                    {id: 4, status: "Done", description: "Buy butter", createdAt: "2021-10-01", updatedAt: "2021-10-02"},
                    {id: 5, status: "Done", description: "Buy cheese", createdAt: "2021-10-01", updatedAt: "2021-10-02"},
                ],
                headers: [
                    {text: "Id", value: "id", sortable: true},
                    {text: "Status", value: "isDone"},
                    {text: "Description", value: "description"},
                    {text: "CreatedAt", value: "createdAt"},
                    {text: "UpdatedAt", value: "updatedAt"},
                    {text: "Actions", value: "operation"},
                ],
                newTodoItem: "",
                newTodoItemErrorMsg: "",
                newItemValidateState: false,
                editTodo: {},
                editTodoItemErrorMsg: "",
                editItemValidateState: false,
                todoEdit: null,
                todoCreate: null,
                loading: true,
                filterText: "",
            };
        },
        methods: {
            validateDescriptionLength(value) {
                return /^.{1,30}$/.test(value.trim());
            },
            createTodoModal() {
                this.newTodoItem = "";
                this.todoCreate.show();
            },
            editTodoModal(id) {
                this.editTodo = JSON.parse(JSON.stringify(this.todoItemsRows.find(x => x.id === id)));
            },
            dateToLocaleString(date) {
                if (!date) {
                    return "null";
                }
                const dateObj = new Date(date);
                return dateObj.toLocaleString();
            },
            getTodoItems() {
                this.loading = true;
                httpGet(`/api/todos`)
                    .then(response => {
                        this.todoItemsRows = response.map(x => {
                            return {
                                id: x.id,
                                isDone: x.isDone,
                                description: x.description,
                                createdAt: this.dateToLocaleString(x.createdAt),
                                updatedAt: this.dateToLocaleString(x.updatedAt),
                                actions: "actions",
                            };
                        });
                    })
                    .catch(err => {
                        console.error(err);
                    })
                    .finally(() => {
                        this.loading = false;
                    });
            },
            createTodoItem() {
                this.loading = true;
                httpPost('/api/todos', {
                    description: this.newTodoItem,
                })
                    .then(() => {
                        this.newTodoItem = "";
                        this.todoCreate.hide();
                    })
                    .catch(err => {
                        console.error(err);
                    })
                    .finally(() => {
                        this.loading = false;
                        this.getTodoItems();
                    });
            },
            updateTodoDescription() {
                const editTodo = this.editTodo;
                this.loading = true;
                httpPut(`/api/todos/${editTodo.id}`, {
                    description: editTodo.description,
                    isDone: editTodo.isDone,
                    id: editTodo.id,
                })
                    .then(() => {
                        this.todoEdit.hide();
                        this.loading = false;
                    })
                    .catch(err => {
                        console.error(err);
                    })
                    .finally(() => {
                        this.loading = false;
                        this.getTodoItems();
                    });
            },
            deleteTodoItem(id) {
                this.loading = true;
                httpDelete(`/api/todos/${id}`)
                    .catch(err => {
                        console.error(err);
                    })
                    .finally(() => {
                        this.loading = false;
                        this.getTodoItems();
                    });
            },
        },
        mounted() {
            this.getTodoItems();
            this.todoEdit = new bootstrap.Modal(this.$refs.todoEditModal, {
                keyboard: false
            })
            this.todoCreate = new bootstrap.Modal(this.$refs.todoCreateModal, {
                keyboard: false
            })
        },
        computed: {
            filteredTodos() {
                let filter = new RegExp(this.filterText, 'i')
                return this.todoItemsRows.filter(el => el.description.match(filter))
            }
        },
        watch: {
            'newTodoItem': {
                handler(newVal, prevVal) {
                    // 透過 newVal, prevVal 取得監聽前後變數的值
                    if (newVal === prevVal) return;
                    this.newItemValidateState = this.validateDescriptionLength(newVal);
                    if (this.newItemValidateState) {
                        this.newTodoItemErrorMsg = "";
                    } else {
                        this.newTodoItemErrorMsg = "Description length should be 1-30 characters.";
                    }
                },
                immediate: false
            },
            'editTodo.description': {
                handler(val) {
                    this.editItemValidateState = this.validateDescriptionLength(val);
                    if (this.editItemValidateState) {
                        this.editTodoItemErrorMsg = "";
                    } else {
                        this.editTodoItemErrorMsg = "Description length should be 1-30 characters.";
                    }
                },
                immediate: false
            }
        }
    })
;

app.mount("#app");