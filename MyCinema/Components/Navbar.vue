<template>
    <nav class="navbar is-primary" role="navigation" aria-label="main navigation">
        <div class="container">
            <div class="navbar-brand">
                <a class="navbar-item" href="/">
                    <i class="fa fa-film"></i>
                    <span style="margin-left: 10px">MyCinema</span>
                </a>
                <router-link class="navbar-item" to="/Reservation">Zarezerwuj bilet</router-link>
                <router-link class="navbar-item" to="/Repertoire">Repertuar</router-link>
                <router-link class="navbar-item" to="/Home">Informacje o kinie</router-link>
                <router-link class="navbar-item" to="/PriceList">Cennik</router-link>

                <router-link class="navbar-item" to="/User">User</router-link>
                <router-link class="navbar-item" to="/Employee">Employee</router-link>
                <router-link class="navbar-item" to="/Registration">User Registration</router-link>
                <button class="button navbar-burger">
                    <span></span>
                    <span></span>
                    <span></span>
                </button>
            </div>

        <div style="flex: 1 0 0"></div>    
<!-- 
        <div style="border: 1px solid white; padding: 10px;">
            <span style="color: white;">{{this.username}}</span>
        </div> -->

        <div class="navbar-brand">
            {{isAuthorised}}
            <router-link v-if="isAuthorised" class="navbar-item" to="/Login">Zaloguj</router-link>
            <a v-else-if="!isAuthorised" class="navbar-item" v-on:click="goToUserProfile()">Zalogowano jako: {{username}}</a>
        </div>
        </div>

    </nav>
</template>

<script>
    import Auth from "../Scripts/auth.js";

    export default {
        name: 'MyNavbar',
        data: function () {
            return {
                username: "Zaloguj się!",
                isAuthorised: false
            }
        },
        created: function () {
            this.getUser();
        },
        methods: {
            getUser() {
                return axios.post("Auth/Login/Identity")
                .then((res) => {
                    console.log(res)
                    this.username = res.data.Login;
                    this.isAuthorised = res.data.isAuthorised;
                });
            },

            logIn() {

                // Takiseer SuperPass
                Auth.login(this.login, this.password).then((res) => {
                    console.log(res);
                    
                    this.isAuthorised = res.data.isAuthorised;
                   // this.$router.go({ name: 'ConfirmReservation'});
                });
            },

            logout() {
                Auth.logout();
            },

            goToUserProfile() {
                this.$router.push({ path: '/Registration'});
            }
        }
    }
</script>

<style lang="scss">
    @import "Styles/Variables";

    .bg-poster {
        width: 100%;
    }
</style>