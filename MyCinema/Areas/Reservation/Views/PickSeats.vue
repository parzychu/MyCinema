<template>
    <div>
        <h1>PickSeats</h1>

        <seats-picker @changed="onSeatsPickerChanged"></seats-picker>

        {{pickedSeats}}

        <router-link :to="{name: 'LogInPage', params: { reservationId: pickedSeats[0]}}"
            class="button is-primary">Dalej</router-link>
  </div>
    </div> 

</template>

<script>
    import SeatsPicker from 'Components/SeatsPicker/SeatsPicker.vue';

    export default {
        name: 'PickSeats',
        components: {
            'seats-picker': SeatsPicker
        },
        data: function() {
            return {
                pickedSeats: []
            }
        },
        methods: {
            onSeatsPickerChanged: function(value) {
                this.pickedSeats = value;
                console.log(value)
            }
        }
    }
</script>

<style>

</style>