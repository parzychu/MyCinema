<template>
    <div>
        <h1>PickMovie</h1>

        <currently-playing-section></currently-playing-section>
    </div> 
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