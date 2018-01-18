<template>
  <section class="section is-fullheight my-pick-cinema">
    <div class="section-title">
      <h2 class="title is-2">Pick Cinema</h2>
    </div>
    <div class="pick-cinema-list">
      <div v-for="cinema in cinemas" 
      :key="cinema.id" @click="pickCinema(cinema)" 
      :class="{'is-active': cinema.isActive}" 
      class="pick-cinema-cinema">
        {{cinema.name}}
      </div>

      <router-link :to="{name: 'PickSeance', params: { cinemaId: cinemaId}}" class="reservation-next-btn">
        <span>Dalej</span>
        <i class="fa fa-arrow-circle-right" aria-hidden="true"></i>
        </router-link>
    </div>
  </section>
</template>

<script>

import Utils from "Utils/Utils";

  export default {
    name: 'PickCinema',
    data: function () {
      return {
        cinemas: [],
        cinemaId: null,
        previousSelectedCinema: null
      }
    },
    created: function () {
        axios.post("Reservation/Reservation/GetCinemas", { movieId: this.$route.params.movieId })
            .then((res) => {
                this.cinemas = res.data;
            }).catch((e) => {
                console.error(e);
            });
    },
    methods: {
      pickCinema: function(cinema) {
        this.cinemaId = cinema.id;

        Utils.toggleIsActiveProp(cinema, this.previousSelectedCinema);
      }
    }
  }
</script>

<style lang="scss">
@import "Styles/Variables";

@mixin pick-seance-box() {
    border-left: 3px solid transparent;
    background: white;
    color: $my-color-primary;
    flex: 0 0 50%;
    padding: 10px 20px;
    transition: background-color .2s, color .2s;

    &.is-active {
        box-shadow: 0px 0px 5px white;
        color: white;
        background-color: $my-color-primary;
        border-left: 3px solid $my-color-primary;
    }

    &:hover {
          box-shadow: 0px 0px 30px rgba(0,0, 0, 0.15);
              z-index: 5;

              &:before {
                content: "";
                position: absolute;
                top: 0;
                right: 0;
                bottom: 0;
                left: 0;
                background-color: rgba($my-color-primary, .10);
              }
        }
}

.my-pick-cinema {
  .pick-cinema-list {
    display: flex;
    flex-wrap: wrap;
  }

.pick-cinema-cinema {
        @include pick-seance-box;
            
        font-size: 36px;
        position: relative;
        flex: 1 1 49%;
        max-width: 50%;
        margin: 1px;
        
    }
}

</style>