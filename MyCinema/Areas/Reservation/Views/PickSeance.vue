<template>
    <div>
        <h1>PickSeance</h1>

        <router-link :to="{name: 'PickSeats', params: { seanceId: 1}}">Pick seance 1</router-link>
        <router-link :to="{name: 'PickSeats', params: { seanceId: 2}}">Pick seance 2</router-link>
    </div> 
</template>

<script>
export default {
    name: 'PickSeance',
  data () {
    return {
      msg: 'Hello from vue-loader!'
    }
  }
}
</script>

<style>
</style>