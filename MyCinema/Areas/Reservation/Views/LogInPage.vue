<template>
    <section class="section is-fullheight my-pick-cinema">
        <div class="section-title">
            <h2 class="title is-2">Log in</h2>
        </div>
        <div class="section-body">
            <div class="column is-6 is-offset-3"> 
                <div class="field">
                    <p class="control has-icons-left has-icons-right">
                        <input class="input is-medium" type="email" v-model="login" placeholder="Login">
                        <span class="icon is-medium is-left">
      <i class="fa fa-envelope"></i>
    </span>
                        <span class="icon is-medium is-right">
      <i class="fa fa-check"></i>
    </span>
                    </p>
                </div>
                <div class="field">
                    <p class="control has-icons-left">
                        <input class="input is-medium" type="password" v-model="password" placeholder="Password">
                        <span class="icon is-medium is-left">
      <i class="fa fa-lock"></i>
    </span>
                    </p>
                </div>
                

                <button v-on:click="logIn()">Login</button>
                </div>
        </div>
        </section>
</template>

<script>
    export default {
        name: 'LogInPage',
        data() {
            return {
                movies: [],
                login: "",
                password: ""
            }
        },
        created: function () {
            axios.post("Reservation/Reservation/GetMovies")
                .then((res) => {
                    this.movies = res.data;
                }).catch((e) => {
                    console.error(e);
                });
        },
        methods: {
            logIn() {
                // Takiseer SuperPass
                axios.post("Auth/Login/Login", {
                    "userName": this.login,
                    "password": this.password
                })
            }
        }
    }
</script>

<style>
    /* @import 'bulma/css/bulma.css'; */
</style>