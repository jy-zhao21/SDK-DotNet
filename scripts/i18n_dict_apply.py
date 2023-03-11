import argparse
import json
import os

def main():
    script_path = os.path.dirname(os.path.realpath(__file__))

    # Parse arguments
    parser = argparse.ArgumentParser(description='Apply a dictionary for i18n')
    parser.add_argument('lang', type=str, help='Language code')
    args = parser.parse_args()

    # Load the dictionary
    entries = []

    with open(os.path.join(script_path, '..', 'i18n', args.lang + '.json'), 'r', encoding='utf-8') as f:
        entries = json.load(f)

    # Apply the dictionary
    for file in os.listdir(os.path.join(script_path, '..', 'src')):
        if not file.endswith('.cs'):
            continue

        with open(os.path.join(script_path, '..', 'src', file), 'r', encoding='utf-8') as f:
            lines = f.readlines()

        for i in range(len(lines)):
            for entry in entries:
                if f"/// {entry['prefix']}{entry['key']}{entry['suffix']}" in lines[i]:
                    lines[i] = lines[i].replace(entry['key'], entry[args.lang])

        with open(os.path.join(script_path, '..', 'src', file), 'w', encoding='utf-8') as f:
            f.writelines(lines)

    # Overwrite README.md with README.<lang>.md
    if os.path.exists(os.path.join(script_path, '..', f'README.{args.lang}.md')):
        with open(os.path.join(script_path, '..', f'README.{args.lang}.md'), 'r', encoding='utf-8') as f:
            lines = f.readlines()

        with open(os.path.join(script_path, '..', 'README.md'), 'w', encoding='utf-8') as f:
            f.writelines(lines)

    # Overwrite Doxyfile with Doxyfile.<lang>
    if os.path.exists(os.path.join(script_path, '..', f'Doxyfile.{args.lang}')):
        with open(os.path.join(script_path, '..', f'Doxyfile.{args.lang}'), 'r', encoding='utf-8') as f:
            lines = f.readlines()

        with open(os.path.join(script_path, '..', 'Doxyfile'), 'w', encoding='utf-8') as f:
            f.writelines(lines)

if __name__ == '__main__':
    main()