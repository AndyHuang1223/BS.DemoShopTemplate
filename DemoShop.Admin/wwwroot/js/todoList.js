const domainName = ""; // api domain name

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
            editTodo: {},
            todoEdit: null,
            todoCreate: null,
            loading: true,
            filterText: "",
        };
    },
    methods: {
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
        async getTodoItems() {
            try {
                const response = await axios.get(`${domainName}/api/todos`);
                const data = response.data;
                this.todoItemsRows = data.map(x => {
                    return {
                        id: x.id,
                        isDone: x.isDone,
                        description: x.description,
                        createdAt: this.dateToLocaleString(x.createdAt),
                        updatedAt: this.dateToLocaleString(x.updatedAt),
                        actions: "actions",
                    };
                });
                this.loading = false;
                return data;
            } catch (err) {
                console.log(err)
            }
        },
        async createTodoItem() {
            this.loading = true;
            if (/^\s*$/.test(this.newTodoItem)) {
                this.newTodoItem = "";
                return;
            }
            try {
                await axios.post(`${domainName}/api/todos`, {
                    description: this.newTodoItem,
                });
                this.newTodoItem = "";
                this.todoCreate.hide();
                await this.getTodoItems();
                this.loading = false;
            } catch (err) {
                console.log(err);
            }
        },
        async updateTodoDescription() {
            this.loading = true;
            try {
                const editTodo = this.editTodo
                await axios.put(`${domainName}/api/todos/${editTodo.id}`, {
                    description: editTodo.description,
                    isDone: editTodo.isDone,
                    id: editTodo.id,
                });
                this.todoEdit.hide();
                await this.getTodoItems();
                this.loading = false;
            } catch (err) {
                console.log(err)
            }
        },
        async deleteTodoItem(id) {
            this.loading = true;
            try {
                await axios.delete(`${domainName}/api/todos/${id}`);
                await this.getTodoItems();
                this.loading = false;
            } catch (err) {
                console.log(err)
            }
        }
    },
    async mounted() {
        await this.getTodoItems();
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
    }
});

app.mount("#app");