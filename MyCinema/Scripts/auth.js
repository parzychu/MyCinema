



// URL and endpoint constants
const API_URL = 'http://localhost:3001/'
const LOGIN_URL = API_URL + 'sessions/create/'
const SIGNUP_URL = API_URL + 'users/'

export default {

  // User object will let us check authentication status
  user: {
    authenticated: false
  },

  // Send a request to the login URL and save the returned JWT
  login(login, password, redirect) {
      return axios.post("Auth/Login/Login", {
          "userName": login,
          "password": password
      }).then((response) => {
        console.log(response)

        this.user.authenticated = true;

        console.log(redirect)
        

        return response;
      }).catch(error => {
        console.error(error);
      });
  },

  signup(context, creds, redirect) {
    context.$http.post(SIGNUP_URL, creds, (data) => {
      localStorage.setItem('id_token', data.id_token)
      localStorage.setItem('access_token', data.access_token)

      this.user.authenticated = true

      if(redirect) {
        router.go(redirect)
      }

    }).error((err) => {
      context.error = err
    })
  },

  // To log out, we just need to remove the token
  logout() {
    localStorage.removeItem('id_token')
    localStorage.removeItem('access_token')
    this.user.authenticated = false;

    console.log("auth logout");
    return axios.post("Auth/Login/Logout");
  },

  checkAuth() {
    axios.post("Auth/Login/Identity").then((res) => {
      this.user.authenticated = res.data.IsAuthenticated,
      this.user.usermane = res.data.Login
    });
  },

  // The object to be passed as a header for authenticated requests
  getAuthHeader() {
    return {
      'Authorization': 'Bearer ' + localStorage.getItem('access_token')
    }
  }
}