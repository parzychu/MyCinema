<template>
    <section class="section is-fullheight my-pick-cinema">
        <div class="section-title">
            <h2 class="title is-2">Pick Seats</h2>
        </div>
        <div class="pick-cinema-screen">Ekran</div>
        <div class="section-body">
            <seats-picker @changed="onSeatsPickerChanged" :seanceId="this.$route.params.seanceId"></seats-picker>

            {{pickedSeats}}

        <button v-on:click="reserveSeats()" class="reservation-next-btn"><span>Dalej</span></button>
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
            }
        }
    }
</script>

<style>

    .pick-cinema-screen {
            color: gray;
    border: 1px solid gray;
    padding: 2px 0;
    margin: 0 auto;
    width: 500px;
    text-align: center;
    margin-bottom: 50px;
    }

    .pick-cinema-screen.is-taken {
        background-image: repeating-linear-gradient(-45deg,
      transparent,
      transparent 10px,
      gray 10,
      gray 10);
    }
</style>