<template>
    <section class="section is-fullheight my-pick-cinema">
        <div class="section-title">
            <h2 class="title is-2">Pick Seats</h2>
        </div>
        <div class="section-body">
            <seats-picker @changed="onSeatsPickerChanged"></seats-picker>

            {{pickedSeats}}

            <router-link :to="{name: 'LogInPage', params: { reservationId: pickedSeats[0]}}" class="button is-primary">Dalej</router-link>
        </div>
    </section>
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