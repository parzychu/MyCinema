
<template>
    <div class="my-movie-preview">
        <div class="movie-preview-title">{{ movie.name }}</div>
        <div class="movie-preview-content">
            <img class="bg-poster" :src="'http://lorempixel.com/240/360/'+getRandomTheme()+'/'+getRandomNumber()"/>
            <div class="movie-preview-overlay">
                <router-link :to="{name: 'PickCinema', params: {movieId: movie.id}}"
                class="button is-medium is-outlined is-inverted is-primary">Rezerwuj</router-link>
            </div>
            <div class="movie-preview-info">
                <div class="movie-preview-duration"><span class="icon is-small"><i class="fa fa-film"></i></span><span>{{movie.runningTime}} min</span></div>
            </div>
        </div>
        

    </div>
</template>

<script>
    export default {
        name: 'MoviePreviewItem',
        props: ['movie'],


        mounted: function () {
            console.log(this.movie, "movue")
        }, 
        methods: {
            getRandomTheme: function() {
                var randomNumber = Math.round(Math.random() * 6)
                switch (randomNumber) {
                    case 1:
                        return 'nightlife';
                        case 2: 
                        return 'fashion';
                        case 3:
                        return 'people';
                        case 4: 
                        return 'city';
                        case 5:
                        return 'sports';
                        case 6: 
                        return 'animals';
                        default:
                        return 'technics'; 
                }
            },

            getRandomNumber: function() {
                return Math.round(Math.random() * 7) + 1;
            }
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
            transition: transform 0.35s, background-color 0.3s, border-color 0.3s;

            &:hover {
                border-color: $my-color-primary !important;
                background-color: $my-color-primary !important;
                color: white !important;
            }
        }
        
        .movie-preview-content {
            position: relative;
            min-height: 300px;
            min-width: 230px;
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
            color: $my-color-gray-text;
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