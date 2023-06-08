import 'package:flutter/material.dart';
import 'package:flutter_signin_button/flutter_signin_button.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // TRY THIS: Try running your application with "flutter run". You'll see
        // the application has a blue toolbar. Then, without quitting the app,
        // try changing the seedColor in the colorScheme below to Colors.green
        // and then invoke "hot reload" (save your changes or press the "hot
        // reload" button in a Flutter-supported IDE, or press "r" if you used
        // the command line to start the app).
        //
        // Notice that the counter didn't reset back to zero; the application
        // state is not lost during the reload. To reset the state, use hot
        // restart instead.
        //
        // This works for code too, not just values: Most code changes can be
        // tested with just a hot reload.
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const MyHomePage(title: 'Givvin'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});

  // This widget is the home page of your application. It is stateful, meaning
  // that it has a State object (defined below) that contains fields that affect
  // how it looks.

  // This class is the configuration for the state. It holds the values (in this
  // case the title) provided by the parent (in this case the App widget) and
  // used by the build method of the State. Fields in a Widget subclass are
  // always marked "final".

  final String title;

  @override
  State<MyHomePage> createState() => SignInSignUpPage();
}

 class SignInSignUpPage extends State<MyHomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: <Widget>[
            Image.asset(
              'assets/images/logo.png', // Replace with your logo image path
              height: 150,
            )
          ],
        ),
      ),
      floatingActionButton: Column(
        mainAxisAlignment: MainAxisAlignment.end,
        children: <Widget>[
                 SignInButtonBuilder(
                    text: 'Sign up with Google',
                    icon: Icons.account_balance,
                    onPressed: () {
                     Navigator.push(
                                              context,
                                              MaterialPageRoute(
                                                  builder: (context) => SignInPage()
                                              )
                                            );
                    },
                    textColor: const Color.fromRGBO(0, 0, 0, 0.54),
                     backgroundColor: Color(0xFFFFFFFF),
                  ),
          SizedBox(height: 16.0),
          SignInButton(
            Buttons.Google,
            text: "Sign in with Google",
            onPressed: () {},
          ),
          SizedBox(height: 16.0),
          SignInButtonBuilder(
            text: 'Sign in with BankID',
            icon: Icons.account_balance,
            onPressed: () {},
            backgroundColor: Colors.blueGrey[700]!,
          )
        ],
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerFloat,
    );
  }
}

class SignInPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Sign In'),
      ),
      body: Container(
        padding: EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: <Widget>[
   SizedBox(height: 16.0),
           SignInButton(
             Buttons.Google,
             text: "Sign in with Google",
             onPressed: () {},
           ),
           SizedBox(height: 16.0),
      SignInButtonBuilder(
            text: 'Sign in with BankID',
            icon: Icons.account_balance,
            onPressed: () {},
            backgroundColor: Colors.blueGrey[700]!,
          )
          ],
        ),
      ),
    );
  }
}