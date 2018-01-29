<template>
    <section class="section is-fullheight my-pick-cinema">
        <div class="section-body">
            <div class="column is-6 is-offset-3">

                <h2 class="title is-3">Log in </h2>
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

                <router-link :to="{path: '/Registration'}">
                    <span>Zarejestruj się</span>

                </router-link>

                <div v-on:click="logIn()" class="reservation-btn-next">
                    <span>Zaloguj</span>
                    <i class="fa fa-arrow-circle-right" aria-hidden="true"></i>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
    import auth from "../../../Scripts/auth.js";

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
                auth.login(this.login, this.password).then((res) => {
                    console.log(res.data.IsEmployee);
                    if (res.data.IsEmployee) {
                        this.$router.push('/Employee');
                    } else {
                        this.$router.push('/Reservation');
                    }
                });
            }
        }
    }
</script>

<style>
    /* @import 'bulma/css/bulma.css'; */
</style>