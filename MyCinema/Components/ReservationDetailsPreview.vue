

<template>
    <div class="card">
        <div class="card-header">
            <p class="card-header-title">
                Szczegóły rezerwacji
            </p>
        </div>
        <div class="reservation-details">
            <div class="left-column">
                <div>
                    Film:
                </div>
                
                <div>
                    Kino:
                </div>
                <div>
                    Data:
                </div>
                <div>
                    Cena:
                </div>
                <div>
                    Zarezerwowano:
                </div>
            </div>
            <div class="right-column">
                <div>
                    {{source.movieTitle}}
                </div>
                <div>
                    {{source.cinema}}
                </div>
                <div>
                    {{source.date}} {{source.time}}
                </div>
                <div>
                    44zł
                </div>
                <div v-for="(row, index) in source.seats" :key="index">
                    <div>
                        <span>Rząd: {{row[0].row}} </span>
                        <span>Miejsca: </span><span v-for="(seat, index) in row" :key="index">{{seat.column}},</span>
                    </div>
                </div>
            </div>
        </div>
        </div>
</template>

<script>
    export default {
        name: 'RepertoirePreview',
        props: ['source'],
    }
</script>

<style lang="scss">

</style>
