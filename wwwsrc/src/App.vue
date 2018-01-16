<template>
  <div id="app">
    <Error></Error>
    <Message></Message>
    <router-view/>
  </div>
</template>

<script>
  import Error from './components/Error'
  import Message from './components/Message'
  export default {
    name: 'app',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('authenticate')
    },
    components: {
      Error,
      Message
    }
  }
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
  .bl{
    display: block;
  }
  .border{
    border: 2px solid black;
  }
</style>