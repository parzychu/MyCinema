<template>
    <nav class="navbar is-primary" role="navigation" aria-label="main navigation">
        <div class="container">
            <div class="navbar-brand">
                <a class="navbar-item" href="https://bulma.io">
            <img src="https://bulma.io/images/bulma-logo.png" 
            alt="Bulma: a modern CSS framework based on Flexbox" width="112" height="28">
            </a>
                <router-link class="navbar-item" to="/Reservation">Reservation</router-link>
                <router-link class="navbar-item" to="/Home">Home</router-link>

                <button class="button navbar-burger">
            <span></span>
            <span></span>
            <span></span>
            </button>
            </div>
        </div>
    </nav>
</template>

<script>
    export default {
        name: 'MyNavbar'
    }
</script>

<style lang="scss">
    @import "Styles/Variables";
    @import "Styles/Main";

    .bg-poster {
        width: 100%;
    }
</style>