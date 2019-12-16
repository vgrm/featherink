import React, { Component } from 'react';

import Typography from '@material-ui/core/Typography';
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import RalewayWoff2 from '../fonts/Raleway-Black.ttf';

const raleway = {
    fontFamily: 'Raleway',
    fontStyle: 'normal',
    fontDisplay: 'swap',
    fontWeight: 1000,
    src: `
    local('Raleway'),
    local('Raleway-Black'),
    url(${RalewayWoff2}) format('woff2')
  `,
    unicodeRange: 'U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF',
};

const theme = createMuiTheme({
    typography: {
        fontFamily: 'Raleway',
    },
    overrides: {
        MuiCssBaseline: {
            '@global': {
                '@font-face': [raleway],
            },
        },
    },
});

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <h1>FeatherInk L3</h1>
            <ThemeProvider theme={theme}>
                <Typography> where designers meet their clients </Typography>
                </ThemeProvider>
        <p>Welcome to graphics design solutions page</p>
      </div>
    );
  }
}
