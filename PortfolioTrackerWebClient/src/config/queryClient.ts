import { QueryCache, QueryClient, MutationCache } from '@tanstack/react-query';

const nonRetryErrorCodes = [403, 401, 400, 404, 409];

export const queryClient = new QueryClient({
    queryCache: new QueryCache({}),
    mutationCache: new MutationCache(),
    defaultOptions: {
        queries: {
            // eslint-disable-next-line @typescript-eslint/no-explicit-any
            retry(failureCount, error: any) {
                return error.status && nonRetryErrorCodes.includes(error.status)
                    ? false
                    : failureCount <= 2
                      ? true
                      : false;
            },
        },
    },
});
