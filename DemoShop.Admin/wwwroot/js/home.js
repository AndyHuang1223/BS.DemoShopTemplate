const domainName = ""; // api domain name
const locale = Quasar.lang.getLocale();
const {createI18n} = VueI18n;

const messages = {
    "en": {
        button: {
            showInfo: "Show Info",
            setTheme: "Change Theme",
            show$qObject: "Show $q Object",
            setAndShowCookie: "Set And Show Cookie",
            changeLocale: "Change Locale",
        },
    },
    "zh-TW": {
        button: {
            showInfo: "顯示資訊",
            setTheme: "更改主題",
            show$qObject: "顯示 $q 物件",
            setAndShowCookie: "設定並顯示 Cookie",
            changeLocale: "更改語言",
        },
    },
};

const i18n = createI18n({
    legacy: false, // for Vue 3
    locale: locale, // 設置預設語言
    messages,
});

const app = Vue.createApp({
    data() {
        return {
            $q: null,
            locale: locale,
            localeOptions: [
                {value: "en", label: "English", quasarLang: Quasar.lang.enUS},
                {value: "zh-TW", label: "繁體中文", quasarLang: Quasar.lang.zhTW},
            ],
            todoItemsIsLoading: false,
            todoItemStatus: "all",
            todoItemsRows: [],
            todoItemsColumns: [
                {
                    name: "id",
                    required: true,
                    label: "Id",
                    align: "left",
                    field: row => row.id,
                    sortable: true,
                },
                {
                    name: "status",
                    required: true,
                    label: "Status",
                    align: "left",
                    field: row => row.isDone,
                    sortable: true,
                },
                {
                    name: "description",
                    required: true,
                    label: "Description",
                    align: "left",
                    field: row => row.description,
                    sortable: false,
                },
                {
                    name: "createdAt",
                    required: true,
                    label: "CreatedAt",
                    align: "left",
                    field: row => row.createdAt,
                    sortable: true,
                },
                {
                    name: "updatedAt",
                    required: false,
                    label: "UpdatedAt",
                    align: "left",
                    field: row => row.updatedAt,
                    sortable: true,
                },
                {
                    name: "actions",
                    required: false,
                    label: "Actions",
                    align: "left",
                    sortable: false,
                },
            ],
            todoItemsPagination: {
                sortBy: "id",
                descending: false,
                page: 1,
                rowsPerPage: 10,
            },
            searchTodoItem: "",
            newTodoItem: "",
            loadingState: false,
        };
    },
    methods: {
        changeLocale(newLocale) {
            this.locale = newLocale;
            this.changeI18n(newLocale);
            this.changeQuasarLocale(newLocale);
        },
        changeI18n(newLocale) {
            this.$i18n.locale = newLocale;
        },
        changeQuasarLocale(newLocale) {
            const targetLang = this.localeOptions.find((option) => option.value === newLocale);
            if (!targetLang) {
                console.warn(`Unsupported locale: ${newLocale}`);
                Quasar.lang.set(Quasar.lang.enUS);
            } else {
                Quasar.lang.set(targetLang.quasarLang);
            }
        },
        dateToLocaleString(date) {
            if (!date) {
                return "null";
            }
            const dateObj = new Date(date);
            return dateObj.toLocaleString();
        },
        filterMethod(rows, terms) {
            this.todoItemsIsLoading = true;
            const result = rows.filter(row =>
                Object.values(row).some(val =>
                    String(val).toLowerCase().indexOf(terms.toLowerCase()) > -1,
                ));
            this.todoItemsIsLoading = false;
            return result;
        },
        async getTodoItems() {
            this.todoItemsIsLoading = true;
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
                this.$q.notify("Get todo items successfully.");
                this.todoItemsIsLoading = false;
                return data;
            } catch (err) {
                this.$q.notify("Failed to get todo items.");
            }
        },
        async createTodoItem() {
            this.loadingState = true;
            this.todoItemsIsLoading = true;
            if (/^\s*$/.test(this.newTodoItem)) {
                this.$q.notify("Please input todo item.");
                this.newTodoItem = "";
                this.loadingState = false;
                this.todoItemsIsLoading = false;
                return;
            }
            try {
                const response = await axios.post(`${domainName}/api/todos`, {
                    description: this.newTodoItem,
                });
                this.newTodoItem = "";
                this.$q.notify("Create todo item successfully.");
                this.loadingState = false;
                await this.getTodoItems();
                this.todoItemsIsLoading = false;
            } catch (err) {
                this.$q.notify("Failed to create todo item.");
            }
        },
        async updateTodoDescription(val, init, id) {
            this.todoItemsIsLoading = true;
            try {
                const targetTodo = this.todoItemsRows.find(x => x.id === id);
                const response = await axios.put(`${domainName}/api/todos/${id}`, {
                    description: val,
                    isDone: targetTodo.isDone,
                    id: id,
                });
                this.$q.notify("Update todo item successfully.");
                await this.getTodoItems();
                this.todoItemsIsLoading = false;
            } catch (err) {
                this.$q.notify("Failed to update todo item.");
            }
        },
        async deleteTodoItem(id) {
            this.todoItemsIsLoading = true;
            try {
                const response = await axios.delete(`${domainName}/api/todos/${id}`);
                this.$q.notify(`Delete todo item successfully.${id}`);
                this.getTodoItems();
                this.todoItemsIsLoading = false;
            } catch (err) {
                this.$q.notify("Failed to delete todo item.");
            }
        },
        async updateTodoStatus(id, isDone) {
            this.todoItemsIsLoading = true;
            try {
                const targetTodo = this.todoItemsRows.find(x => x.id === id);
                const response = await axios.put(`${domainName}/api/todos/${id}`, {
                    description: targetTodo.description,
                    isDone: isDone,
                    id: id,
                });
                this.$q.notify("Update todo status successfully.");
                await this.getTodoItems();
                this.todoItemsIsLoading = false;
            } catch (err) {
                this.$q.notify("Failed to update todo status.");
            }
        },
    },
    mounted() {
        this.$q = this.$q || window.Quasar;
        this.$q.loading.show({
            message: "Loading...",
        });
        this.getTodoItems().then((data) => {
            this.$q.loading.hide();
        });
    },
});

app.use(Quasar);
Quasar.lang.set(Quasar.lang.zhTW);
Quasar.iconSet.set(Quasar.iconSet.fontawesomeV6);
app.use(i18n);
app.mount("#q-app");

// console.log(app.config.globalProperties.$q);
