<template>
  <div class="my-pick-cinema">
    <h1>PickCinema</h1>

  <div v-for="cinema in cinemas"
    :key="cinema.id"
    @click="pickCinema(cinema)"
    :class="{'is-active': cinema.isActive}"
    class="pick-cinema-cinema">
      {{cinema.name}}
  </div>

    <router-link :to="{name: 'PickSeance', params: { cinemaId: cinemaId}}"
    class="pick-cinema-cinema is-active">Dalej</router-link>
  </div>
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
        axios.post("Reservation/Reservation/GetCinemas")
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
@import "Styles/Main";
@import "Styles/Variables";

.my-pick-cinema {

@mixin pick-seance-box() {
            border: 1px solid $my-color-primary;
            box-shadow: 0px 0px 5px $my-color-primary;
            background: white;
            color: $my-color-primary;
            border-radius: 4px;
            
            padding: 10px 20px;
            margin: 0 10px;

            &.is-active {
                border: 1px solid white;
                box-shadow: 0px 0px 5px white;
                background: $my-color-primary;
                color: white;
            }
        }

    .pick-cinema-cinema {
        @include pick-seance-box;
            
        font-size: 36px;
    }
}

</style>