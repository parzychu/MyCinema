
<template>
    <div>
        <router-link to="/foo">Go to Foo</router-link>
        <router-link to="/bar">Go to Bar</router-link>
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
