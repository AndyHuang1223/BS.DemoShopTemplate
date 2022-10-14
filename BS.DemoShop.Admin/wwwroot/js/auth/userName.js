const api = {
  getUserName: '/Auth/GetUserName'
}

const apiCaller = {
  getUserName: () => httpGet(api.getUserName)
}

const authUserNameVue = new Vue({
  el: '#auth-username',
  data: {},
  methods: {
    clickMe() {
      apiCaller.getUserName()
        .then((res) => {
          console.log(res)
        })
    }
  }
})