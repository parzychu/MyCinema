

<template>
    <div>

        <p>Index vue</p>
        <currently-playing-section></currently-playing-section>

        <span>ddd</span>
    </div>
</template>

<script>
    import CurrentlyPlayingSection from './Views/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';
    import MoviePreviewItem from './Views/MoviePreview/MoviePreview.vue';

    export default {
        name: 'HomeView',
        components: {
            MoviePreviewItem,
            CurrentlyPlayingSection
        }
    }
</script>

<style lang="scss">
    @import "Styles/Variables";
    @import "Styles/Main";

    body {
        background: #eee;
    }
</style>
