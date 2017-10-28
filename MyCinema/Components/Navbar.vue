
<template>
    <div>
        <router-link to="/Reservation">Reservation</router-link>
        <router-link to="/Home">Home</router-link>
    </div>
</template>

<script>
    export default {
        name: 'MyNavbar'
    }
</script>

<style lang="scss">
    @import "Styles/Variables";
    @import "Styles/Main";

    body {
        background: $my-color-black;
    }

    .bg-poster {
        width: 100%;
    }
</style>
