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
                <!-- <router-link class="navbar-item" to="/Home">Informacje o kinie</router-link> -->
                <router-link class="navbar-item" to="/PriceList">Cennik</router-link>

                <!-- <router-link class="navbar-item" to="/User">User</router-link>
                <router-link class="navbar-item" to="/Employee">Employee</router-link> -->
                <!-- <router-link class="navbar-item" to="/Registration">User Registration</router-link> -->
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
            <template v-if="!isAuthorised">
                    <a class="navbar-item" @click="goToUserProfile()" slot="trigger">
                        <span>Zaloguj</span>
                    </a>
                </template>
                
                <template v-if="isAuthorised">
            <b-dropdown>
                
                    <button class="button is-primary navbar-item" slot="trigger">
                        <span>Zalogowano jako: {{username}} </span>
                        <b-icon icon="menu-down"></b-icon>
                    </button>
        
                    <b-dropdown-item @click="goToUserProfile()">Profil</b-dropdown-item>
                    <b-dropdown-item @click="logout()">Wyloguj</b-dropdown-item>
        </b-dropdown>
        
                </template>            

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
                isAuthorised: false,
                isEmployee: false,
                isClient: false
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
                    this.isAuthorised = res.data.IsAuthenticated;
                    this.isEmployee = res.data.IsEmployee;
                    this.isClient = res.data.IsClient;
                });
            },

            logout() {
                Auth.logout();
                this.isAuthorised = null;
                this.$router.push({ path: '/Login'});
            },

            goToUserProfile() {
                this.getUser().then(() => {
                    if (!this.isAuthorised) {
                        this.$router.push({ path: '/Login'});
                    } else if (this.isEmployee) {
                        this.$router.push({ path: '/Employee'});
                    } else if (this.isClient) {
                        this.$router.push({ path: '/User'});
                    }

                })
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