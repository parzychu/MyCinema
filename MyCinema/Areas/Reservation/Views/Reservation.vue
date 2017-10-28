

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
    import MoviePreviewItem from 'Components/MoviePreview/MoviePreview.vue';

    export default {
        name: 'HomeView',
        components: {
            MoviePreviewItem,
            CurrentlyPlayingSection
        }
    }
</script>

<style lang="scss">
    @import "Styles/Main";
</style>
