<template>
    <div>
        <button @click="showMyKeepsList(); getKeepsByUserId();">My Keeps</button>
        <div v-if="showMyKeeps">
            <div class="my-keeps-area" v-if="myKeeps.length > 0">
                <div class="my-keeps" v-for="myKeep in myKeeps">
                    {{myKeep}}
                </div>
            </div>
            <div class="my-keeps-area" v-else>
                <p>You have no keeps.</p>
            </div>
        </div>
        <button @click='showKeeps'>Keeps</button>
        <div class="showKeepArea" v-if="showAllKeeps">
            <div v-for="keep in keeps">
                {{keep}}
            </div>
        </div>
    </div>

</template>

<script>
    export default {
        name: 'ShowKeeps',
        data() {
            return {
                showAllKeeps: false,
                showMyKeeps: false
            }
        },
        mounted() {
            this.$store.dispatch('getAllKeeps')
            // this.$store.dispatch('getKeepsByUserId', this.user.id)
            // console.log(this.user.id)
        },

        methods: {
            showKeeps() {
                this.showAllKeeps = !this.showAllKeeps
            },
            showMyKeepsList() {
                this.showMyKeeps = !this.showMyKeeps
            },
            getKeepsByUserId() {
                this.$store.dispatch('getKeepsByUserId', this.user.id)
            }
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            myKeeps() {
                return this.$store.state.myKeeps
            },
            user() {
                return this.$store.state.user
            }
        },
        components: {

        }
    }


</script>

<style>
</style>