import React from 'react';
import { Text, StyleSheet, ScrollView } from 'react-native';
import Greeting from './src/components/Greeting';
import {SafeAreaView } from 'react-native-safe-area-context';
import Counter from './src/components/Counter';

function App(): React.JSX.Element {
  return (
      <SafeAreaView style={styles.container}>
        <ScrollView contentContainerStyle={styles.content}>
          <Text style={styles.title}>Hello React Native!</Text>
          <Text style={styles.subtitle}>with TypeScript 🚀</Text>
          <Greeting name="Anna" age={25} />
          <Greeting name="Piotr" isVip={true} />
          <Greeting name="Kasia" age={30} isVip={true} />
          <Greeting name="Jan" />
          <Counter />
        </ScrollView>
      </SafeAreaView>

  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f5f5f5',
  },
  content: {
    alignItems: 'center',
    paddingVertical: 16,
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#333',
  },
  subtitle: {
    fontSize: 16,
    color: '#666',
    marginTop: 8,
    marginBottom: 16,
  },
});

export default App;