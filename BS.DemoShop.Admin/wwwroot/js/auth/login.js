(function IIFE() {
  const HOME_PAGE = '/'
const api = { login: '/Auth/Login' }
const apiCaller = { login: (loginQuery) => httpPost(api.login, loginQuery) }

const authLoginVue = new Vue({
  el: '#authLogin',
  data: {
    login: {
      userName: '',
      password: ''
    }
  },
  methods: {
    loginBtn() {
      handleLogin({ ...this.login })
    }
  }
})

function handleLogin(loginQuery) {
  apiCaller.login(loginQuery)
  .then((res) => {
    if (res.isSuccess) {
      const { token, expireTime } = res.body
      setToken(token, expireTime)
      redirectToHome()
    }
  })
}

function setToken(token, expire) {
  Cookies.set('token', token, {
    expires: new Date(expire * 1000)
  })
}

function redirectToHome() {
  window.location.href = HOME_PAGE
}
})()