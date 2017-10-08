
<template>
    <div>
        <p>About page  xxdd</p>

        <!--<movie-preview-item v-for="movie in currentMovies"
                            :key="movie.Id"
                            :movie="movie"></movie-preview-item>-->
    </div>
</template>

<script>
    import MoviePreviewItem from '../MoviePreview/MoviePreview.vue';

    export default {
        name: 'CurrentlyPlayingSection',

        components: {
            MoviePreviewItem
        },
        data: function() {
            return {
                currentMovies: []
            }
        },
        mounted: function () {
            this.getCurrentMovies();
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
    @import "Styles/Variables";
    @import "Styles/Main";

    body {
        background: $my-color-black;
    }
</style>