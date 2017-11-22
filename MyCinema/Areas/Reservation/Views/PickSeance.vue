<template>
    <section class="section is-fullheight my-pick-seance">
        <div class="section-title">
            <h2 class="title is-2">Pick Seance</h2>
        </div>
        <div class="section-body">
            <div class="pick-seance-container">
            <div :key="day.date" class="pick-seance-day" 
                :class="{'is-active': day.isActive}"
                v-for="day in seanceDates" 
                v-on:click="changeDay(day)">
                {{day.date}}
            </div>
        </div>
        <div class="pick-seance-container">
            <div v-for="hour in pickedDayHours"
                :key="hour.hour" 
                :class="{'is-active': hour.isActive}"
                @click="changeHour(hour)"
                class="pick-seance-hour">
                {{hour.hour}}
            </div>
        </div>
        <router-link v-if="seanceId"
            :to="{name: 'PickSeats', params: { seanceId: seanceId}}" 
            class="button is-primary">
                Dalej
        </router-link>
        </div>
    </section>
</template>
<script>
    import Utils from "Utils/Utils";

    export default {
        name: "PickSeance",
        data: function () {
            return {
                seanceDates: [],
                pickedDayHours: [],
                seanceId: null
            };
        },
        methods: {
            changeDay: function (day) {
                this.pickedDayHours = day.seances;
                Utils.toggleIsActiveProp(day, this.previousDayActive);
            },
            changeHour: function(hour) {
                this.seanceId = hour.id;
                Utils.toggleIsActiveProp(hour, this.previousHourActive);
            }
        },
        created: function () {
            axios.post("Reservation/Reservation/GetDates", {
                cinemaId: this.$route.params.cinemaId
            })
                .then((res) => {
                    this.seanceDates = res.data;
                }).catch((e) => {
                    console.error(e);
                });
        }
    };
</script>
<style lang="scss">
    @import "Styles/Main";
    @import "Styles/Variables";

    .my-pick-seance {
        @mixin pick-seance-box() {
            border: 1px solid $my-color-primary;
            box-shadow: 0px 0px 5px $my-color-primary;
            background: white;
            color: $my-color-primary;
            border-radius: 4px;
            
            padding: 10px 20px;
            margin: 0 10px;

            &.is-active {
                border: 1px solid white;
                box-shadow: 0px 0px 5px white;
                background: $my-color-primary;
                color: white;
            }
        }

        .pick-seance-container {
            display: flex;
            justify-content: center;
            margin-bottom: 60px;
        }

        .pick-seance-day {
            @include pick-seance-box;
            
            font-size: 36px;
        }

        .pick-seance-hour {
            @include pick-seance-box;

            font-size: 42px;
        }
    }
</style>