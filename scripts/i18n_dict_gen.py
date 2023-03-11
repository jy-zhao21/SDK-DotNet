import argparse
import json
import os
import re

def main():
    script_path = os.path.dirname(os.path.realpath(__file__))

    # Parse arguments
    parser = argparse.ArgumentParser(description='Generate a dictionary for i18n')
    parser.add_argument('lang', type=str, help='Language code')
    args = parser.parse_args()

    # Extract all possible entries
    entries = []

    for file in os.listdir(os.path.join(script_path, '..', 'src')):
        if not file.endswith('.cs'):
            continue

        with open(os.path.join(script_path, '..', 'src', file), 'r', encoding='utf-8') as f:
            regex = re.compile(r'^ *\/\/\/ +(<summary>|<param name="\S+">|<returns>|)([^<\n].*?)(<\/summary>|<\/param>|<\/returns>|)$')
            for line in f:
                match = regex.match(line)
                if match:
                    print(line)
                    entries.append({
                        'key': match.group(2),
                        'prefix': match.group(1),
                        'suffix': match.group(3),
                        args.lang: '<no translation>'
                    })

    # Write a JSON file
    with open(os.path.join(script_path, '..', 'i18n', args.lang + '.json'), 'w', encoding='utf-8') as f:
        json.dump(entries, f, indent=4, ensure_ascii=False)

if __name__ == '__main__':
    main()