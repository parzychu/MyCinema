

<template>
    <div>
        <p>Index vue</p>
        <p>_________________________</p>
        <currently-playing-section></currently-playing-section>

        <span>ddd</span>
    </div>
</template>

<script>
    import CurrentlyPlayingSection from './Views/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';

    export default {
        name: 'HomeView',
        components: {
            CurrentlyPlayingSection
        }
    }
</script>

<style lang="scss">
    @import "Styles/Main";
</style>
