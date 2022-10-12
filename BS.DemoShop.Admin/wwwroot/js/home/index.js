;(function IIFE() {
  const api = {
    getUserName: '/Auth/GetUserName'
  }
  
  const apiCaller = {
    getUserName: () => httpGet(api.getUserName)
  }
  
  const homeIndexVue = new Vue({
    el: '#home-index',
    data: {
      username: ''
    },
    methods: {
      clickMe() {
        apiCaller.getUserName()
          .then((res) => {
            this.username = res.body
          })
      }
    }
  })
})()