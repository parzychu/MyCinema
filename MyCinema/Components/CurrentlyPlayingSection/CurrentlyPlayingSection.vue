
<template>
    <div style="display: grid; grid-template-columns: repeat(auto-fill, minmax(200px, 1fr)); grid-gap: 20px;">
        <movie-preview-item v-for="movie in movies"
                            :key="movie.Id"
                            :movie="movie"></movie-preview-item>
    </div>
</template>

<script>
    import MoviePreviewItem from 'Components/MoviePreview/MoviePreview.vue';

    export default {
        name: 'CurrentlyPlayingSection',
        props: ['movies'],
        components: {
            MoviePreviewItem
        },
        data: function() {
            return {
                currentMovies: []
            }
        },
        mounted: function () {
            
        },
        methods: {
            getCurrentMovies: function () {
                this.currentMovies = [];

                axios.get("/Home/Movies/CurrentlyPlaying")
                    .then((response) => {
                        console.log("currentlyPlaying", response.data)
                        this.currentMovies = response.data;
                    })
                    .catch(error => {
                        console.error(error);
                    });
            }
        }

    }
</script>

<style lang="scss">
    @import "Styles/Main";

</style>