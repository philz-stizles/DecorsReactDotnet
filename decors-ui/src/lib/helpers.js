// 1 dollar = 100cents
export const formatPrice = (price) => {
  return new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
  }).format(price / 100);
};

export const getUniqueValues = (data, type) => {
  let unique = data.map((item) => item[type]);
  if (type === 'colors') {
    // color would return an array of arrays
    unique = unique.flat(); // therefore we need to flatten it here
  }

  return ['all', ...new Set(unique)]; // Set takes in an array of values and stores unique values
};
