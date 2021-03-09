.PHONY: setup-infrastructure
setup-infrastructure:
	docker-compose --file ./docker-compose.infrastructure.yml up --detach

.PHONY: teardown-infrastructure
teardown-infrastructure:
	docker-compose --file ./docker-compose.infrastructure.yml down

.PHONY: create-database
create-database: setup-infrastructure
	docker-compose --file ./docker-compose.infrastructure.yml run --rm \
		-e PGHOST="postgres" 		\
		-e PGUSER="postgres"		\
		-e PGPASSWORD="postgres"	\
		postgres createdb 'library'

.PHONY: drop-database
drop-database: setup-infrastructure
	docker-compose --file ./docker-compose.infrastructure.yml run --rm \
	-e PGHOST="postgres" 		\
	-e PGUSER="postgres"		\
	-e PGPASSWORD="postgres"	\
	postgres dropdb --force 'library'

.PHONY: migrate-database
migrate-database:
	./sqitch deploy --target db:pg://postgres:postgres@localhost:5432/library

.PHONY: verify-database
verify-database:
	./sqitch verify --target db:pg://postgres:postgres@localhost:5432/hospital

.PHONY: run
run: setup-infrastructure
	echo "not implemented"
