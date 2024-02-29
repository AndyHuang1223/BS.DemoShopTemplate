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
            userQuasarPlatformColumns: [
                {
                    name: "Id",
                    align: "left",
                    label: "Custom Id",
                    field: row => row.id,
                    sortable: true,
                },
                {
                    name: "name",
                    required: true,
                    label: "Display Name",
                    align: "left",
                    field: row => row.name,
                    format: value => `${value}`,
                    sortable: true,
                },
                {
                    name: "value",
                    align: "left",
                    label: "Display Value",
                    field: row => row.value,
                    sortable: true,
                },
            ],
            userQuasarPlatformRows: [],
            locale: locale,
            localeOptions: [
                {value: "en", label: "English", quasarLang: Quasar.lang.enUS},
                {value: "zh-TW", label: "繁體中文", quasarLang: Quasar.lang.zhTW},
            ],
        };
    },
    methods: {
        setTheme() {
            this.$q.dark.set(true);
        },
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
    },
});

app.use(Quasar);
Quasar.lang.set(Quasar.lang.zhTW);
Quasar.iconSet.set(Quasar.iconSet.fontawesomeV6);
app.use(i18n);
app.mount("#q-app");
