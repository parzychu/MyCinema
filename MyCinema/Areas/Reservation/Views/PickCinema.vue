<template>
  <section class="section">
    <nav class="breadcrumb has-arrow-separator is-large" aria-label="breadcrumbs">
      <ul>
        <li>
          <router-link :to="{name: 'PickMovie'}">Film</router-link>
        </li>
        <li class="is-active">
          <router-link :to="{name: 'PickCinema'}">Wybierz Kino</router-link>
        </li>
      </ul>
    </nav>

    <div class="tile is-ancestor" style="flex-wrap: wrap">
      <div class="tile is-parent is-6" v-for="cinema in cinemas" :key="cinema.id">
        <div class="tile notification has-border-left"  @click="pickCinema(cinema)" :class="{'is-primary': cinema.isActive}">
          
          <p class="title"> {{cinema.name}}</p>
        </div>
      </div>
    </div>

    <router-link :to="{name: 'PickSeance', params: { cinemaId: cinemaId}}" class="reservation-btn-next">
        <span>Dalej</span>
        
      <i class="fa fa-arrow-circle-right level-left" aria-hidden="true"></i>
    </router-link>
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
      axios.post("Reservation/Reservation/GetCinemas", {
          movieId: this.$route.params.movieId
        })
        .then((res) => {
          this.cinemas = res.data;
        }).catch((e) => {
          console.error(e);
        });
    },
    methods: {
      pickCinema: function (cinema) {
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
      box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.15);
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