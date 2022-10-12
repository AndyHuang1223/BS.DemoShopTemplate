const api = {
  getUserName: '/Auth/GetUserName'
}

const apiCaller = {
  getUserName: () => httpGet(api.getUserName)
}

const homeIndexVue = new Vue({
  el: '#home-index',
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