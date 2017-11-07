<template>
    <section class="section is-fullheight my-pick-cinema">
        <div class="section-title">
            <h2 class="title is-2">Pick Movie</h2>
        </div>
        <div class="section-body">
            <currently-playing-section :movies="movies"></currently-playing-section>
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