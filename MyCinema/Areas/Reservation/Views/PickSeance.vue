<template>
    <div class="my-pick-seance">
        <h1>PickSeance</h1>
        <div class="pick-seance-container">
            <div :key="day.day" class="pick-seance-day" 
                :class="{'is-active': day.isActive}"
                v-for="day in seanceDates" 
                v-on:click="changeDay(day)">
                {{day.day}}
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
            class="pick-seance-hour is-active">
                Dalej
        </router-link>
    </div>
</template>
<script>
    export default {
        name: "PickSeance",
        data: function () {
            return {
                seanceDates: [{
                    day: "28.10",
                    hours: [{
                        hour: "10:40",
                        id: "11"
                    }, {
                        hour: "14:40",
                        id: "13"
                    }, {
                        hour: "18:40",
                        id: "15"
                    }]
                }, {
                    day: "29.10",
                    hours: [{
                        hour: "10:20",
                        id: "16"
                    }, {
                        hour: "14:20",
                        id: "18"
                    }, {
                        hour: "18:20",
                        id: "19"
                    }]
                }, {
                    day: "30.10",
                    hours: [{
                        hour: "10:30",
                        id: "21"
                    }, {
                        hour: "14:30",
                        id: "23"
                    }, {
                        hour: "18:30",
                        id: "25"
                    }]
                }],
                pickedDayHours: [],
                seanceId: null
            };
        },
        methods: {
            changeDay: function (day) {
                this.pickedDayHours = day.hours;
                this.previousDayActive && (this.previousDayActive.isActive = false);
                day.isActive = !day.isActive;
                this.previousDayActive = day;
            },
            changeHour: function(hour) {
                this.seanceId = hour.id;
                this.previousHourActive && (this.previousHourActive.isActive = false);
                hour.isActive = !hour.isActive;
                this.previousHourActive = hour;
            }
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