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
      msg: 'Hello from vue-loader!'
    }
  }
}
</script>

<style>
</style>