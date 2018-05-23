<template>
    <div>

        <b-field>
            <div class="field is-grouped">
                <div class="control">
                    <div class="field has-addons">
                        <p class="control">
                            <button class="button is-primary" v-on:click="previousDay()">
                                <span class="icon">
                                    <i class="fa fa-arrow-left"></i>
                                </span>
                            </button>
                        </p>
                        <p class="control">
                            <b-datepicker placeholder="Click to select..." icon="calendar" v-model="selectedDate">
                            </b-datepicker>
                        </p>
                        <p class="control">
                            <button class="button is-primary" v-on:click="nextDay()">
                                <span class="icon">
                                    <i class="fa fa-arrow-right"></i>
                                </span>
                            </button>
                        </p>
                    </div>
                </div>
                <div class="control">
                    <b-select placeholder="Wybierz kino" v-model="selectedCinema" @input="getRepertoire()">
                        <option v-for="cinema in cinemas" :key="cinema.id" :value="cinema.id">
                            {{cinema.name}}
                        </option>
                    </b-select>
                </div>
            </div>

        </b-field>
        <b-table :data="repertoire" :striped="true" :hoverable="true" :mobile-cards="true">

            <template slot-scope="props">

                <b-table-column label="Tytuł filmu" width="800">
                    {{ props.row.title }}
                </b-table-column>


                <b-table-column label="Zarezerwuj">
                    <div class="field is-grouped">
                        <!-- // {{seance.id}} -->
                        <p class="control" v-for="(seance, index) in props.row.seances" :key="index">
                            <button class="button is-primary" v-on:click="goToSeance(seance.id)">{{seance.time}}</button>
                        </p>
                    </div>

                </b-table-column>
            </template>

            <template slot="empty">
                <section class="section">
                    <div class="content has-text-grey has-text-centered">

                        <p>Tego dnia nie wyświetlamy filmów w tym kinie.</p>
                    </div>
                </section>
            </template>
        </b-table>
    </div>
</template>

<script>
    import CurrentlyPlayingSection from 'Components/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';

    export default {
        name: 'RepertoirePreview',
        components: {
            CurrentlyPlayingSection
        },
        created: function () {
            this.getRepertoire();
            this.getCinemas();
        },
        data: function () {
            return {
                selectedCinema: -1,
                repertoire: [],
                cinemas: [],
                selectedDate: new Date()
            }
        },
        methods: {
            previousDay: function () {
                this.selectedDate.setDate(this.selectedDate.getDate() - 1)
                this.getRepertoire();
            },
            nextDay: function () {
                this.selectedDate.setDate(this.selectedDate.getDate() + 1)
                this.getRepertoire();
            },
            getRepertoire: function () {
                axios.post("Repertoire/Repertoire/GetRepertoire", {
                        cinemaId: this.selectedCinema,
                        date: this.selectedDate
                    })
                    .then((res) => {
                        this.repertoire = res.data;
                    }).catch((e) => {
                        console.error(e);
                    });
            },
            getCinemas: function () {
                    axios.post("Repertoire/Repertoire/GetCinemas")
                    .then((res) => {
                        this.cinemas = res.data;
                        this.selectedCinema = this.cinemas[0].id;
                    }).catch((e) => {
                        console.error(e);
                    });
            },

            goToSeance: function (seanceId) {
                axios.post("Reservation/Reservation/GetResevationParams", {
                        seanceId: seanceId
                    })
                    .then((res) => {
                        console.log(res.data);
                        this.$router.push({
                            name: 'PickSeats',
                            params: {
                                movieId: res.data.movieId,
                                cinemaId: res.data.cinemaId,
                                seanceId: res.data.id
                            }
                        });
                    });
            }
        }
    }
</script>

<style lang="scss">

</style>