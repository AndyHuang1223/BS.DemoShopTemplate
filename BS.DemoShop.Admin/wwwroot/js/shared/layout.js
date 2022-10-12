;(function IIFE() {
  const api = {
    logout: '/Auth/Logout'
  }
  
  const apiCaller = {
    logout: () => httpGet()
  }
  
  let logoutModalVue = new Vue({
    el: '#logoutModal',
    methods: {
      logoutBtn() {
        // TODO: 敲 logout API
      }
    }
  })
})()