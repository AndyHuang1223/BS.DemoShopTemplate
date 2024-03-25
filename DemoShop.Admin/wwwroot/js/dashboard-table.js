const {createApp} = Vue;

const App = {
    components: {
        EasyDataTable: window["vue3-easy-data-table"],
    },
    data() {
        return {
            headers: [
                {text: "Name", value: "Name"},
                {text: "Position", value: "Position"},
                {text: "Office", value: "Office"},
                {text: "Age", value: "Age", sortable: true},
                {text: "Startdate", value: "Startdate"},
                {text: "Salary", value: "Salary"},
            ],
            items: [],
            loading: false,
        };
    },
    methods: {
        getAll() {
            this.loading = true;
            axios.get('https://raw.githubusercontent.com/flyingtrista/FileStorage/main/datatableData.json')
                .then(res => {
                    if (res.status === 200) {
                        toastr.success("Data loaded successfully!");
                        this.items = res.data.data;
                    }
                })
                .catch(error => {
                    console.error(error);
                })
                .finally(() => {
                    this.loading = false;
                });
        },
    },
    mounted() {
        this.getAll();
    },
};

createApp(App).mount("#app");