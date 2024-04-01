(function IIFE() {
    const HOME_PAGE = '/'
    const api = { login: '/api/Auth/Login' }
    const apiCaller = { login: (loginQuery) => httpPost(api.login, loginQuery) }

    const authLoginVue = Vue.createApp({
        data(){
            return {
                login: {
                    userName: '',
                    password: ''
                }
            }
        },
        methods: {
            loginBtn() {
                handleLogin({ ...this.login })
            }
        }
    })
    authLoginVue.mount('#authLogin')
    function handleLogin(loginQuery) {
        apiCaller.login(loginQuery)
            .then((res) => {
                console.log(res)
                if (res.isSuccess) {
                    const { token, expireTime } = res.body
                    setToken(token)
                    redirectToHome()
                }
            })
            .catch(err => {
                console.error(err)
            })
    }

    function setToken(token) {
        localStorage.setItem('token', token)
    }

    function redirectToHome() {
        window.location.href = HOME_PAGE
    }
})()