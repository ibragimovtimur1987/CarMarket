#!/bin/bash
set -e

export PATH="$PATH:/root/.dotnet/tools"

echo "Applying EF migrations..."
dotnet ef database update

echo "Starting application..."
exec "$@