;(function IIFE() {
  const api = {
    logout: '/Auth/Logout'
  }
  
  const apiCaller = {
    logout: (query) => httpPost(api.logout, query)
  }
  
  let logoutModalVue = new Vue({
    el: '#logoutModal',
    methods: {
      logoutBtn() {
        const query = { token: getToken() }
        
        apiCaller.logout(query)
          .then((res) => {
            removeToken()
            redirectToLogin()
          })
      }
    }
  })

  function getToken() {
    return Cookies.get('token')
  }

  function removeToken() {
    Cookies.remove('token')
  }

  function redirectToLogin() {
    const LOGIN_PAGE = '/login'
    window.location.href = LOGIN_PAGE
  }
})()