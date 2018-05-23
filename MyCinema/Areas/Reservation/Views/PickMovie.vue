<template>
    <section class="section is-fullheight my-pick-cinema">
        <nav class="breadcrumb has-arrow-separator is-large" aria-label="breadcrumbs">
            <ul>
                <li class="is-active" ><router-link :to="{name: 'PickMovie'}"> Wybierz Film</router-link></li>
            </ul>
        </nav>
        <div class="section-body">
            <currently-playing-section :movies="movies"></currently-playing-section>
            Wykorzystane zdjęcia pochodzą ze strony: http://lorempixel.com/ tam można naleźć informację o ich autorach.
        </div>
    </section>
</template>

<script>

import CurrentlyPlayingSection from 'Components/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';

export default {
  name: 'PickMovie',
  components: {
      CurrentlyPlayingSection
  },
  data () {
    return {
      movies: []
    }
  },
  created: function () {
      axios.post("Reservation/Reservation/GetMovies")
          .then((res) => {
              this.movies = res.data;
          }).catch((e) => {
              console.error(e);
          });
  }
}
</script>

<style>
</style>