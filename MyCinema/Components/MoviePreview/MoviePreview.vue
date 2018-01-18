
<template>
    <div class="my-movie-preview">
        <div class="movie-preview-title">{{ movie.name }}</div>
        <img class="bg-poster" src="https://media.multikino.pl/thumbnails/50/rc/MjkwMEEy/eyJ0aHVtYm5haWwiOnsic2l6ZSI6WyIxMDAwMCIsIjEwMDAwIl0sIm1vZGUiOiJpbnNldCJ9fQ==/uploads/images/films_and_events/twoj-vincent-pl_b9d917af7b.JPG"/>
        <div class="movie-preview-overlay">
            <router-link :to="{name: 'PickCinema', params: {movieId: movie.id}}"
            class="button is-medium is-outlined is-inverted is-primary">Rezerwuj</router-link>
        </div>
        <div class="movie-preview-info">
            <div class="movie-preview-duration"><span class="icon is-small"><i class="fa fa-film"></i></span><span>{{movie.runningTime}} min</span></div>
        </div>
        

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
@import "Styles/Variables";

    .my-movie-preview {
        position: relative;
        overflow: hidden;
        cursor: pointer;

        .bg-poster {
            width: 100%;
        }

        .button {
            transform: translateY(100%);
            transition: transform 0.35s;
        }

        .movie-preview-overlay {
            background: rgba($my-color-bg, .4);
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            opacity: 0.00001;
            transition: opacity 0.35s;
        }

        .movie-preview-info {
            position: absolute;
            bottom: 0;
            top: auto;
            right: 0;
            left: 0;
            transform: translateY(100%);
            transition: transform 0.35s;
            background: $my-color-white;
            padding: 15px 20px;
        }

        .movie-preview-title {
            color: white;
            font-size: 1.25rem;
            font-weight: 400;
            line-height: 1.25;
            padding: 10px 15px 15px;
            text-align: center;
        }
        
        .movie-preview-duration {
            color: $my-color-gray-icon-active;
            margin-bottom: 5px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1;
            display: flex;
            justify-content: flex-end;

            .icon {
                margin-right: 7px; 
                color: $my-color-gray-icon;
            }
        }

        &:hover .movie-preview-overlay {
            opacity: 1;
        }

        &:hover {
            .button,
            .movie-preview-info {
                transform: none;
            }
        }
    }

</style>