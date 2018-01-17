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
    /* margin-top: 60px; */
    overflow: hidden;
  }

  .bl {
    display: block;
  }

  .ilb {
    display: inline-block;
  }

  .border {
    border: 2px solid black;
  }

  .custom-btn {
    background: black;
    color: white;
    border: 0;
    border-radius: 5px;
    font-size: 1.4rem;
    font-weight: bold;
  }

  .account-btn {
    margin-top: 35%;
    margin-bottom: 34%;
    margin-right: 20%;
  }

  .cursor:hover {
    cursor: pointer;
  }
  .btn-no-border{
    border: 0;
    background: none;
    position: absolute;
    /* top:2%; */
    /* z-index:1; */
  }
</style>