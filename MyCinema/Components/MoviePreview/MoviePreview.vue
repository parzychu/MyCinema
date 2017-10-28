
<template>
    <div class="movie-preview">
        <img class="bg-poster" src="https://media.multikino.pl/thumbnails/50/rc/MjkwMEEy/eyJ0aHVtYm5haWwiOnsic2l6ZSI6WyIxMDAwMCIsIjEwMDAwIl0sIm1vZGUiOiJpbnNldCJ9fQ==/uploads/images/films_and_events/twoj-vincent-pl_b9d917af7b.JPG"/>
        Film 1
        sss
        <a> Rezerwuj </a>
        <div>{{ movie.Title }}</div>

    </div>
</template>

<script>
    export default {
        name: 'MoviePreviewItem',
        props: ['movie'],


        mounted: function () {
            console.log(this.movie, "movue")
        }
    }
</script>

<style lang="scss">
    

    .bg-poster {
        width: 100%;
    }
</style>