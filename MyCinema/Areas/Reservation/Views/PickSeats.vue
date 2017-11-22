<template>
    <section class="section is-fullheight my-pick-cinema">
        <div class="section-title">
            <h2 class="title is-2">Pick Seats</h2>
        </div>
        <div class="section-body">
            <seats-picker @changed="onSeatsPickerChanged"></seats-picker>

            {{pickedSeats}}

        <button v-on:click="reserveSeats()">Reserve seats</button>

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
            },
            reserveSeats: function() {
                var reservationInfo = {
                    seanceId: this.$route.params.seanceId,
                    seatIds: this.pickedSeats
                }

                var dopa = "dsada"
                axios.post("Reservation/Reservation/CreateReservation", reservationInfo)
                    .then((res => {
                        this.$router.push({ name: 'ConfirmReservation', params: { reservationId: res.data }});
                    }).bind(this));
                axios.post("Reservation/Reservation/SeatsInSeance")
            }
        }
    }
</script>

<style>

</style>