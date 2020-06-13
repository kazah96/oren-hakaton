const formatLevel = process.env.LINT_FORMAT || 'off'

module.exports = {
  parser: '@typescript-eslint/parser',

  parserOptions: {
    ecmaVersion: 2020,
    jsx: true,
    sourceType: 'module',
  },

  extends: [
    'plugin:react/recommended',
    'prettier/@typescript-eslint',
    'plugin:prettier/recommended',
    'plugin:@typescript-eslint/recommended',
  ],
  settings: {
    react: {
      version: 'detect',
    },
  },

  rules: {
    '@typescript-eslint/explicit-function-return-type': 'off',
    '@typescript-eslint/no-unused-vars': 'off',
    'react/prop-types': 'off',
    '@typescript-eslint/explicit-function-return-type': 'off',
    '@typescript-eslint/no-explicit-any': 'off',
    '@typescript-eslint/no-var-requires': 'off',
    '@typescript-eslint/ban-ts-ignore': 'off',
    '@typescript-eslint/interface-name-prefix': 'off',
    '@typescript-eslint/camelcase': 'off',
    '@typescript-eslint/no-empty-interface': 'off',
    '@typescript-eslint/no-non-null-assertion': 'off',
    'react/jsx-uses-vars': 'warn',
    'react/jsx-uses-react': 'warn',
    'react/react-in-jsx-scope': 'warn',
    'react/jsx-no-target-blank': 'warn',
    'react/no-find-dom-node': 'off',
    'react/display-name': 'off',
    quotes: [formatLevel, 'single', { allowTemplateLiterals: true }],
    'jsx-quotes': [formatLevel, 'prefer-single'],
  },
}
