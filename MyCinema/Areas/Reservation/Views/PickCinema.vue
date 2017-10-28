<template>
    <div>
        <h1>PickCinema</h1>


        <router-link :to="{name: 'PickSeance', params: { cinemaId: 1}}">Pick cinema 1</router-link>
        <router-link :to="{name: 'PickSeance', params: { cinemaId: 2}}">Pick cinema 2</router-link>
            </div> 
</template>

<script>
export default {
    name: 'PickCinema',
  data () {
    return {
      msg: 'Hello from vue-loader!'
    }
  }
}
</script>

<style>
</style>